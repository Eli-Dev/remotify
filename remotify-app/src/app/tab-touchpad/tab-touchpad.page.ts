import { AfterViewInit, Component, ElementRef, ViewChild } from '@angular/core';
import { DomController, GestureController } from '@ionic/angular';
import { WebsocketService } from '../services/websocket.service';
import { MouseParameter } from '../Commands/MouseParameter';
import {SettingsService} from '../services/settings.service';

@Component({
  selector: 'app-tab-touchpad',
  templateUrl: './tab-touchpad.page.html',
  styleUrls: ['./tab-touchpad.page.scss'],
})
export class TabTouchpadPage implements AfterViewInit {

  @ViewChild('box', { read: ElementRef }) box: ElementRef;

  constructor(private websocketService: WebsocketService,
              private settingsService: SettingsService,
              private gestureCtl: GestureController,
              private domCtl: DomController) { }

  async ngAfterViewInit() {
    await this.domCtl.read(() => {
      this.setupGesture();
    });
  }

  setupGesture() {
    const moveGesture = this.gestureCtl.create({
      el: this.box.nativeElement,
      threshold: 0,
      gestureName: 'touchpad',
      onMove: ev => {
        const param: MouseParameter = {
          xDiff: this.settingsService.touchpadSensitivity * ev.deltaX / window.innerWidth,
          yDiff: this.settingsService.touchpadSensitivity * ev.deltaY / window.innerHeight,
          xVelocity: 0,//ev.velocityX / window.innerWidth,
          yVelocity: 0//ev.velocityY / window.innerHeight
        };
        this.websocketService.send({ command: 'mouse', parameters: param });
      }
    });

    moveGesture.enable(true);
  }
}
