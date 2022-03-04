import { Injectable } from '@angular/core';
import { webSocket, WebSocketSubject } from 'rxjs/webSocket';
import { ToastController } from '@ionic/angular';

@Injectable({
  providedIn: 'root'
})
export class WebsocketService {

  public ip: string;
  private webSocket: WebSocketSubject<Message>;

  constructor(public toastController: ToastController) {
  }

  connect() {
    this.webSocket = webSocket<Message>({
      url: `ws://${this.ip}:5000/ws`
    });

    this.webSocket.asObservable().subscribe(
      data => { console.log(data); },
      async error => {

        const toast = await this.toastController.create({
          message: 'Error with the connection - Try re-entering the IP of your PC',
          duration: 2000
        });
        await toast.present();
        this.ip = '';
      }
    );
  }

  send(msg: Message) {
    this.webSocket.next(msg);
  }

}

export interface Message {
  message: string;
}
