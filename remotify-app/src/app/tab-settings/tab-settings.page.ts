import { Component, OnInit } from '@angular/core';
import { WebsocketService } from '../services/websocket.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-tab-settings',
  templateUrl: './tab-settings.page.html',
  styleUrls: ['./tab-settings.page.scss'],
})
export class TabSettingsPage implements OnInit {

  settingsForm: FormGroup;

  constructor(
    public webSocket: WebsocketService,
    public formBuilder: FormBuilder
  ) { }

  ngOnInit() {

    this.settingsForm = this.formBuilder.group({
      ip: [this.webSocket.ip,
        [Validators.required, Validators.pattern(/^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$/)]],
    });
  }

  submitForm() {
    this.webSocket.ip = this.settingsForm.controls.ip.value;
    this.webSocket.connect();

    this.webSocket.send({ message: 'ping' });
    this.settingsForm.controls.ip.setValue(this.webSocket.ip);
  }
}
