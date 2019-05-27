import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    path: 'home',
    loadChildren: './home/home.module#HomePageModule'
  },
  {
    path: 'list',
    loadChildren: './list/list.module#ListPageModule'
  },

  { path: 'about',
   loadChildren: './about/about.module#AboutPageModule' },

  { path: 'cause',
   loadChildren: './cause/cause.module#CausePageModule' },
   
  { path: 'symptoms',
   loadChildren: './symptoms/symptoms.module#SymptomsPageModule' },  { path: 'faqs', loadChildren: './faqs/faqs.module#FAQsPageModule' }

];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
