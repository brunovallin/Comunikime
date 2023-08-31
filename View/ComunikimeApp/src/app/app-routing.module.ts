import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProdutoComponent } from './components/produto/produto.component';
import { ProdutoDetalheComponent } from './components/produto/produto-detalhe/produto-detalhe.component';
import { ProdutoListaComponent } from './components/produto/produto-lista/produto-lista.component';
import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { LojaComponent } from './components/loja/loja.component';

const routes: Routes = [
  {
    path: 'user',
    component: UserComponent,
    children: [{ path: 'login', component: LoginComponent }],
  },
  {
    path: 'produto',
    component: ProdutoComponent,
    children: [
      { path: 'produto-detalhe/:id', component: ProdutoDetalheComponent },
      { path: 'produto-detalhe', component: ProdutoDetalheComponent },
      { path: 'produto-lista', component: ProdutoListaComponent },
    ],
  },

  {
    path: 'produto',
    redirectTo: 'produto/produto-detalhe',
  },

  {path:'loja', component:LojaComponent},

  { path: '', redirectTo: 'produto/produto-lista', pathMatch: 'full' },
  { path: '**', redirectTo: 'produto/produto-lista', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
