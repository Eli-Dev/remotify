import { Component, OnInit } from '@angular/core';
import { FilePicker } from '@robingenz/capacitor-file-picker';

@Component({
  selector: 'app-tab-files',
  templateUrl: './tab-files.page.html',
  styleUrls: ['./tab-files.page.scss'],
})
export class TabFilesPage implements OnInit {

  path = 'hallo';

  constructor() { }

  ngOnInit() {

  }

  async pickFiles() {
    const result = await FilePicker.pickFiles({
      //types: ['image/png'],
      multiple: true,
      readData: true,
    });

    result.files.forEach(f => this.path = f.data);
  };

}
