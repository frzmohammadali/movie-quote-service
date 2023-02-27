
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorizeGuard } from '../api-authorization/authorize.guard';
import { QuotesComponent } from './quotes/quotes.component';
import { TokenComponent } from './token/token.component';

export const routes: Routes = [
  { path: '', component: QuotesComponent, pathMatch: 'full' },
  { path: 'token', component: TokenComponent, canActivate: [AuthorizeGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
