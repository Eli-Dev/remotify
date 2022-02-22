import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { TabKeyboardPageRoutingModule } from './tab-keyboard-routing.module';

import { TabKeyboardPage } from './tab-keyboard.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    TabKeyboardPageRoutingModule
  ],
  declarations: [TabKeyboardPage]
})
export class TabKeyboardPageModule {}
