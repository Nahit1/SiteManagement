import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SiteService {
  baseUrl = environment.apiUrl;
  constructor(private http:HttpClient) { }

  
  getAllSiteByUser(id:string){
    return this.http.get(this.baseUrl + 'Site/GetAllSites?userId=' + id);
  }
}
