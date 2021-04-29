import {Component, NgModule} from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {BrowseBooksComponent} from './browse-books/browse-books.component';
import {AddBookComponent} from './add-book/add-book.component';
import {UpdateBookComponent} from './update-book/update-book.component';

const routes: Routes = [
  {path: 'addBook', component : AddBookComponent},
  {path: 'browseBooks', component : BrowseBooksComponent},
  {path: 'updateBook', component : UpdateBookComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
