import { AfterViewInit, Component, ElementRef, ViewChild } from '@angular/core';
import { DomController, GestureController } from '@ionic/angular';
import { WebsocketService } from '../services/websocket.service';
import { MouseParameter } from '../Commands/MouseParameter';

@Component({
  selector: 'app-tab-touchpad',
  templateUrl: './tab-touchpad.page.html',
  styleUrls: ['./tab-touchpad.page.scss'],
})
export class TabTouchpadPage implements AfterViewInit {

  @ViewChild('box', { read: ElementRef }) box: ElementRef;

  constructor(private websocketService: WebsocketService,
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
          xDiff: ev.deltaX / window.innerWidth,
          yDiff: ev.deltaY / window.innerHeight,
          xVelocity: ev.velocityX / window.innerWidth,
          yVelocity: ev.velocityY / window.innerHeight
        };
        this.websocketService.send({ command: 'mouse', parameters: param });
      }
    });

    moveGesture.enable(true);
  }
}
