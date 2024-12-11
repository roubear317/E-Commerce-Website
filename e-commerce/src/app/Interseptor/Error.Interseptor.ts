import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router, RouterModule } from "@angular/router";
import { catchError, Observable, throwError } from "rxjs";


@Injectable()
export class ErrorInterseptor implements HttpInterceptor {

    constructor(private roote :Router) { }
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(
            catchError((error) => {
                if(error){
                if (error.status === 404) {
                    this.roote.navigate(['/Not-found']);
                }
               if (error.status === 500) {
                    this.roote.navigate(['/server-error']);
                }
            }
            return throwError(() => error);
            }))
        };
    }


