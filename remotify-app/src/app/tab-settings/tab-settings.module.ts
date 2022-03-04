import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { TabSettingsPageRoutingModule } from './tab-settings-routing.module';

import { TabSettingsPage } from './tab-settings.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    TabSettingsPageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [TabSettingsPage]
})
export class TabSettingsPageModule {}
