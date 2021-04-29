import { Component, OnInit } from '@angular/core';
import {Book} from '../book';
import {LibraryService} from '../bookLibrary.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-browse-books',
  templateUrl: './browse-books.component.html',
  styleUrls: ['./browse-books.component.css']
})
export class BrowseBooksComponent implements OnInit {
  books: Array<Book>;

  constructor(private service: LibraryService) { }

  refresh(author: string, genre: string): void{
    this.service.fetchBooks(author, genre)
      .subscribe(books => this.books = books);
  }

  deleteBook(author: string, title: string): void{
    this.service.deleteBook(author, title).subscribe(() => this.refresh('', ''));
  }

  lendBook(author: string, title: string, lended: string): void {
    if (lended === 'YES') {
      this.service.lendBook(author, title, 'NO').subscribe(() => this.refresh('', ''));
    }
    else if (lended === 'NO')
    {
      this.service.lendBook(author, title, 'YES').subscribe(() => this.refresh('', ''));
    }
  }

  ngOnInit(): void {
    this.refresh('', '');
  }

}
