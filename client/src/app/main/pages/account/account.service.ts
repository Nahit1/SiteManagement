import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { IUser } from '@core/models/user';
import { environment } from 'environments/environment';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  public currentUserData:IUser;
  private currentUserSource = new BehaviorSubject<IUser>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http:HttpClient, private router:Router) { }

  getCurrentUserValue(){
    return this.currentUserSource.value;
  }

  loadCurrentUser(token:string){
    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${token}`);

    return this.http.get(this.baseUrl + 'account/currentUser', {headers}).pipe(
      map((user:IUser) => {
        if(user){
          this.currentUserData = user;
          localStorage.setItem('token', this.currentUserData.token);
          this.currentUserSource.next(this.currentUserData);
        }
      })
    )
  }

  updateCurrentUser(siteId:any, siteName:any){
    this.currentUserSource.next({...this.currentUserSource.value, siteId, siteName});
  }

  login(values:any){
    return this.http.post(this.baseUrl + 'account/login', values).pipe(
      map((user:IUser) =>{
        if(user){
          localStorage.setItem('token', user.token);
          this.currentUserSource.next(user);
        }
      })
    );
  }

  logout(){
    localStorage.removeItem('token');
    this.currentUserSource.next(null);
    this.router.navigateByUrl('/');
  }
}
