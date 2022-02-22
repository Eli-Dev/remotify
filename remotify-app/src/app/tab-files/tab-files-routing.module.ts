import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TabFilesPage } from './tab-files.page';

const routes: Routes = [
  {
    path: '',
    component: TabFilesPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TabFilesPageRoutingModule {}
