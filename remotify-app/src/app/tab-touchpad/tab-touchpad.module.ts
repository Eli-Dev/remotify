import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { TabTouchpadPageRoutingModule } from './tab-touchpad-routing.module';

import { TabTouchpadPage } from './tab-touchpad.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    TabTouchpadPageRoutingModule
  ],
  declarations: [TabTouchpadPage]
})
export class TabTouchpadPageModule {}
