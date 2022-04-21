import { Component, OnInit } from '@angular/core';
import { WebsocketService } from '../services/websocket.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import {SettingsService} from '../services/settings.service';

@Component({
  selector: 'app-tab-settings',
  templateUrl: './tab-settings.page.html',
  styleUrls: ['./tab-settings.page.scss'],
})
export class TabSettingsPage implements OnInit {

  settingsForm: FormGroup;

  constructor(
    public settingsService: SettingsService,
    public formBuilder: FormBuilder
  ) {
  }

  ngOnInit() {

    this.settingsForm = this.formBuilder.group({
      ip: [this.settingsService.ip,
        [Validators.required, Validators.pattern(
          // eslint-disable-next-line max-len
          /^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$/
        )]],
      touchpadSensitivity: [this.settingsService.touchpadSensitivity,
        [Validators.required, Validators.pattern(
          // eslint-disable-next-line max-len
          /^[+-]?([0-9]+\.?[0-9]*|\.[0-9]+)$/
        )]]
    });
  }

  submitForm() {
    this.settingsService.ip = this.settingsForm.controls.ip.value;
    //this.settingsForm.controls.ip.setValue(this.settingsService.ip);
    this.settingsService.touchpadSensitivity = this.settingsForm.controls.touchpadSensitivity.value;
  }
}
