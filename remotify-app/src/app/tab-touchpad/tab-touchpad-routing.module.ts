import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TabTouchpadPage } from './tab-touchpad.page';

const routes: Routes = [
  {
    path: '',
    component: TabTouchpadPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TabTouchpadPageRoutingModule {}
