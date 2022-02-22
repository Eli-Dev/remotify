import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TabKeyboardPage } from './tab-keyboard.page';

const routes: Routes = [
  {
    path: '',
    component: TabKeyboardPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TabKeyboardPageRoutingModule {}
