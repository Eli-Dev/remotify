import { Injectable } from '@angular/core';
import { webSocket, WebSocketSubject } from 'rxjs/webSocket';
import { ToastController } from '@ionic/angular';
import { Command } from '../Commands/Command';

@Injectable({
  providedIn: 'root'
})
export class WebsocketService {

  public ip: string;
  private webSocket: WebSocketSubject<Command<any>>;

  constructor(public toastController: ToastController) {
  }

  connect() {
    if (this.webSocket != null) {
      this.webSocket.unsubscribe();
    }
    this.webSocket = webSocket<Command<any>>({
      url: `ws://${this.ip}:5001/ws`
    });

    this.webSocket.asObservable().subscribe(
      data => { console.log(data); },
      async error => {

        const toast = await this.toastController.create({
          message: 'Error with the connection - Try re-entering the IP of your PC',
          duration: 2000
        });
        await toast.present();
        console.log(error);

        this.webSocket.unsubscribe();
        this.webSocket = null;
      }
    );
  }

  send(cmd: Command<any>) {
    //console.log(cmd);
    if (this.webSocket == null) {
      this.connect();
    }

    this.webSocket.next(cmd);
  }

}
