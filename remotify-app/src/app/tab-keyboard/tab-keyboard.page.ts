import { Component, OnInit } from '@angular/core';
import { KeyboardParameter } from '../Commands/KeyboardParameter';
import { WebsocketService } from '../services/websocket.service';
import { CapacitorMediaSession } from 'media-session-control';

@Component({
  selector: 'app-tab-keyboard',
  templateUrl: './tab-keyboard.page.html',
  styleUrls: ['./tab-keyboard.page.scss'],
})
export class TabKeyboardPage implements OnInit {

  input: string;
  lastLength = 0;

  constructor(private websocketService: WebsocketService) { }

  ngOnInit() {
  }

  keyboardInput() {
    const length = this.input.length;
    let inputChar: string;

    if (length > this.lastLength) {
      inputChar = this.input.charAt(this.input.length - 1);
    }
    else {
      inputChar = 'BACK';
    }

    this.lastLength = length;
    this.sendKey(inputChar);
  }

  useEffect() {
    CapacitorMediaSession.initMediaSession({
      isPlaying: true,
      isActive: true,
      title: 'Listening for volume changes',
      subtitle: 'test',
      artworkUri: 'https://upload.wikimedia.org/wikipedia/commons/thumb/2/21/Speaker_Icon.svg/480px-Speaker_Icon.svg.png',
      position: 0
    }).catch(e => console.log(`Error while trying to create media-session: ${e}`));


    CapacitorMediaSession.addListener('mediaSessionEvent', event => {
      if (event.eventName === 'onVolumeUp') {
        //console.log('up');
        this.sendKey('n');
      }
      else if (event.eventName === 'onVolumeDown') {
        //console.log('down');
        this.sendKey('p');
      }
    });

    /*this.musicControls.create({
      track: 'Tracking volume buttons',
      artist: 'Remotify',
      hasPrev: false,
      hasNext: false,
      hasClose: false,
      isPlaying: true
    }).catch(e => console.log(e));

    this.musicControls.subscribe().subscribe(value => console.log(value));*/

    /*const onVolumeButtonPressed = ({direction}: VolumeButtonPressed) => {
      if (direction === 'up') {
        console.log('Volume up pressed!');
      } else {
        console.log('Volume down pressed!');
      }
    };

    CapacitorVolumeButtons.addListener('volumeButtonPressed', onVolumeButtonPressed);

    const file: MediaObject = this.media.create('/android_asset/public/assets/test.mp3');
    file.play({ playAudioWhenScreenIsLocked: true });

    file.onError.subscribe(error => console.log('error while playing media: ' + error.toString()));
    file.onStatusUpdate.subscribe(status => {
      if (status === MEDIA_STATUS.STOPPED) {
        file.play({ playAudioWhenScreenIsLocked: true });
      }
    });*/
  }

  sendKey(key: string) {
    this.websocketService.send({ command: 'keyboard', parameters: { keyInput: key } });
  }
}
