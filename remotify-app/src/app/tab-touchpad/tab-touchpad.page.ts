import { Component, OnInit } from '@angular/core';
import {WebsocketService} from '../services/websocket.service';

@Component({
  selector: 'app-tab-touchpad',
  templateUrl: './tab-touchpad.page.html',
  styleUrls: ['./tab-touchpad.page.scss'],
})
export class TabTouchpadPage implements OnInit {

  constructor(public websocketService: WebsocketService) { }

  ngOnInit() {
  }

}
