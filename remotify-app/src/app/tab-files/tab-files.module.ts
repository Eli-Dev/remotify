import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { TabFilesPageRoutingModule } from './tab-files-routing.module';

import { TabFilesPage } from './tab-files.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    TabFilesPageRoutingModule
  ],
  declarations: [TabFilesPage]
})
export class TabFilesPageModule {}
