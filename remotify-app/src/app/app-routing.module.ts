import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./tabs/tabs.module').then(m => m.TabsPageModule)
  },
  {
    path: 'tab-touchpad',
    loadChildren: () => import('./tab-touchpad/tab-touchpad.module').then( m => m.TabTouchpadPageModule)
  },
  {
    path: 'tab-keyboard',
    loadChildren: () => import('./tab-keyboard/tab-keyboard.module').then( m => m.TabKeyboardPageModule)
  },
  {
    path: 'tab-files',
    loadChildren: () => import('./tab-files/tab-files.module').then( m => m.TabFilesPageModule)
  },
  {
    path: 'tab-settings',
    loadChildren: () => import('./tab-settings/tab-settings.module').then( m => m.TabSettingsPageModule)
  }
];
@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
