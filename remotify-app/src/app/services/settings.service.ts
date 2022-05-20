import { Injectable } from '@angular/core';
import {WebsocketService} from "./websocket.service";
import {FormBuilder} from "@angular/forms";

@Injectable({
  providedIn: 'root'
})
export class SettingsService {
  private _ip: string;
  private _touchpadSensitivity: number;

  constructor(
    public webSocket: WebsocketService,
  ) { }

  get ip(): string {
    return this._ip;
  }

  get touchpadSensitivity(): number {
    return this._touchpadSensitivity;
  }

  set touchpadSensitivity(value: number) {
    this._touchpadSensitivity = value;
  }

  set ip(value: string) {

    if (value !== this.webSocket.ip) {
      this._ip = value;
      this.webSocket.ip = this._ip;
      this.webSocket.connect();
      this.webSocket.send({ command: 'test', parameters: null });
    }
  }
}
