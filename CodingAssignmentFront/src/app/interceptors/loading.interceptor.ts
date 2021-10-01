import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { LoadingService } from "../_services/loading.service";

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {
  constructor(private readonly LoadingService: LoadingService) { }

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const spinnerSubscription: Subscription = this.LoadingService.spinner$.subscribe();
    return next
      .handle(req)
      .pipe(finalize(() => spinnerSubscription.unsubscribe()));
  }
}
