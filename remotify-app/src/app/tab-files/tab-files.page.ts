import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpEventType, HttpErrorResponse } from '@angular/common/http';
import { FilePicker } from '@robingenz/capacitor-file-picker';
import {ILocalNotification, LocalNotifications} from '@awesome-cordova-plugins/local-notifications/ngx';
import { SettingsService } from '../services/settings.service';
import { FilePath } from '@awesome-cordova-plugins/file-path/ngx';

@Component({
  selector: 'app-tab-files',
  templateUrl: './tab-files.page.html',
  styleUrls: ['./tab-files.page.scss'],
})
export class TabFilesPage implements OnInit {

  constructor(private settings: SettingsService,
              private filePath: FilePath,
              private localNotifications: LocalNotifications,
              private http: HttpClient) { }

  ngOnInit() {

  }

  async pickFiles() {
    const result = await FilePicker.pickFiles({
      multiple: true,
      readData: false
    });

    for (const f of result.files) {

      //const blob = new Blob([new Uint8Array(decode(f.data))], {
      //  type: f.mimeType
      //});
      this.filePath.resolveNativePath(f.path)
        .then(p => {
          this.http.get(p.replace('file://', '_capacitor_file_'), {responseType: 'blob'}).toPromise()
            .then(b => this.sendFile(f.name, b));
        })
        .catch(error => console.log(error));
    }
  };

  async sendFile(fileName: string, data: Blob) {
    const formData = new FormData();
    formData.append('file', data, fileName);

    const progressNotification: ILocalNotification = {
      title: 'Uploading ' + fileName,
      progressBar: { value: 0 },
    };

    this.localNotifications.schedule(progressNotification);

    this.http.post(`http://${this.settings.ip}:5001/api/upload`, formData, {reportProgress: true, observe: 'events'})
      .subscribe({
        next: (event) => {
          if (event.type === HttpEventType.UploadProgress) {
            progressNotification.progressBar = { value: (100 * event.loaded / event.total) };
            this.localNotifications.update(progressNotification);
          }
          else if (event.type === HttpEventType.Response) {
            this.localNotifications.cancel(progressNotification.id);
            this.localNotifications.schedule({
              title: `${fileName} uploaded`
            });
          }
        },
        error: (err: HttpErrorResponse) => console.log(err)
      });
  }

}
