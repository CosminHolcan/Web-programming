import { Component, OnInit } from '@angular/core';
import {LibraryService} from '../bookLibrary.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-update-book',
  templateUrl: './update-book.component.html',
  styleUrls: ['./update-book.component.css']
})
export class UpdateBookComponent implements OnInit {

  constructor(private service: LibraryService, private router: Router) { }

  ngOnInit(): void {
  }

  updateBook(author: string, title: string, pages: string, genre: string): void{
    this.service.updateBook(author, title, Number(pages), genre).subscribe(() => {
      this.router.navigate(['browseBooks']).then(_ => {
      });
    });
  }

}
