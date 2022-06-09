import { AfterViewInit, Component, ElementRef, ViewChild } from '@angular/core';
import { DomController, GestureController } from '@ionic/angular';
import { WebsocketService } from '../services/websocket.service';
import { MouseParameter } from '../Commands/MouseParameter';
import {SettingsService} from '../services/settings.service';
import {GestureDetail} from "@ionic/core/dist/types/utils/gesture";

@Component({
  selector: 'app-tab-touchpad',
  templateUrl: './tab-touchpad.page.html',
  styleUrls: ['./tab-touchpad.page.scss'],
})
export class TabTouchpadPage implements AfterViewInit {

  @ViewChild('box', { read: ElementRef }) box: ElementRef;

  private lastClick = 0;
  private DOUBLE_CLICK_THRESHOLD = 500;

  private lastMouseClick: string;

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
          click: 'none'
        };
        this.websocketService.send({ command: 'mouse', parameters: param });
      },
      onStart: ev => {
        const now = Date.now();

        if (Math.abs(now - this.lastClick) <= this.DOUBLE_CLICK_THRESHOLD) {
          if (ev.startX <= (window.innerWidth / 2)) {
            this.lastMouseClick = 'left';
          }
          else {
            this.lastMouseClick = 'right';
          }
          this.sendMousePress();

          this.lastClick = 0;
        } else {
          this.lastClick = now;
        }
      },
      onEnd: ev => {
        if (this.lastClick === 0) {
          this.releaseMouse();
        }
      }
    });

    moveGesture.enable(true);
  }

  sendLeftMousePress() {
    this.lastMouseClick = 'left';
    this.sendMousePress();
  }

  sendRightMousePress() {
    this.lastMouseClick = 'right';
    this.sendMousePress();
  }

  sendQuickMousePress() {
    this.sendClick(this.lastMouseClick);
    this.releaseMouse();
  }

  sendMousePress() {
    this.sendClick(this.lastMouseClick);
  }

  sendClick(click: string) {
    const param: MouseParameter = {
      xDiff: 0,
      yDiff: 0,
      click
    };
    this.websocketService.send({ command: 'mouse', parameters: param });
  }

  releaseMouse() {
    this.sendClick('release ' + this.lastMouseClick);
  }
}
