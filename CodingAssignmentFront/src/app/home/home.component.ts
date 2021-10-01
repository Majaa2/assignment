import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Subscription } from 'rxjs';
import { Category } from '../_models/category.model';
import { CategoryService } from '../_services/category.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  categories!: Array<Category>;

  constructor(private cs: CategoryService, private sanitizer: DomSanitizer) {
    this.cs.refresh();
    this.cs.categorySub.subscribe((data) => {
      this.categories = data;
    });
  }

  

  ngOnInit(): void {}

  getImage(buffer) {
    return this.sanitizer.bypassSecurityTrustResourceUrl(
      'data:image/png;base64, ' + buffer.substr(104)
    );
  }
}
