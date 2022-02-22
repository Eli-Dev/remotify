import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TabsPage } from './tabs.page';

const routes: Routes = [
  {
    path: 'tabs',
    component: TabsPage,
    children: [
      {
        path: 'touchpad',
        loadChildren: () => import('../tab-touchpad/tab-touchpad.module').then(m => m.TabTouchpadPageModule)
      },
      {
        path: 'keyboard',
        loadChildren: () => import('../tab-keyboard/tab-keyboard.module').then(m => m.TabKeyboardPageModule)
      },
      {
        path: 'files',
        loadChildren: () => import('../tab-files/tab-files.module').then(m => m.TabFilesPageModule)
      },
      {
        path: 'settings',
        loadChildren: () => import('../tab-settings/tab-settings.module').then(m => m.TabSettingsPageModule)
      },
      {
        path: '',
        redirectTo: '/tabs/touchpad',
        pathMatch: 'full'
      }
    ]
  },
  {
    path: '',
    redirectTo: '/tabs/touchpad',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
})
export class TabsPageRoutingModule {}
