import { Component } from '@angular/core';
import {BreakpointObserver, Breakpoints} from '@angular/cdk/layout';
import { Subject } from 'rxjs';
import {takeUntil} from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})


export class AppComponent {
  title = 'CodingAssignmentFront';

  destroyed = new Subject<void>();
  breakpoints = Breakpoints;
  isSmallScreen: boolean = false;

  constructor(breakpointObserver: BreakpointObserver) {
    
    breakpointObserver.observe([
      Breakpoints.XSmall,
      Breakpoints.Small,
      Breakpoints.Medium,
      Breakpoints.Large,
      Breakpoints.XLarge,
    ]).pipe(takeUntil(this.destroyed)).subscribe(result => {
            this.isSmallScreen = breakpointObserver.isMatched('(max-width: 790px)');
    });
  }
  ngOnDestroy() {
    this.destroyed.next();
    this.destroyed.complete();
  }
}
