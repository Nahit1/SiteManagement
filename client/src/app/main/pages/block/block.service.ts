import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BlockService {
  baseUrl = environment.apiUrl;
  constructor(private http:HttpClient) { }


  getAllBlockByUser(siteId:string){
    return this.http.get(this.baseUrl + 'Block/GetAllBlocks?siteId=' + siteId);
  }
}
