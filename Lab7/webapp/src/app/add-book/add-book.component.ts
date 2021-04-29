import { Component, OnInit } from '@angular/core';
import {LibraryService} from '../bookLibrary.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.css']
})
export class AddBookComponent implements OnInit {

  constructor(private service: LibraryService, private router: Router) { }

  ngOnInit(): void {
  }

  addBook(author: string, title: string, pages: string, genre: string): void{
    this.service.addBook(author, title, Number(pages), genre).subscribe(() => {
      this.router.navigate(['browseBooks']).then(_ => {
      });
    });
  }

}
