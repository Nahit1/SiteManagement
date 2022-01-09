import { Component, OnInit } from '@angular/core';
import { IBlock } from '@core/models/block';
import { AccountService } from '../account/account.service';
import { BlockService } from './block.service';

@Component({
  selector: 'app-block',
  templateUrl: './block.component.html',
  styleUrls: ['./block.component.scss']
})
export class BlockComponent implements OnInit {
  [x: string]: any;

  public contentHeader: object;

  public Blocks: IBlock[];


  constructor(private _blockService:BlockService, private _accountService :AccountService) { }

  ngOnInit(): void {
    this.contentHeader = {
      headerTitle: 'Site Listesi',
      breadcrumb: {
        type: '',
        links: [
          
        ]
      }
    };
    this.currentUser$ = this._accountService.currentUser$;
    this.getBlocks();
  }

  getBlocks(){
    
    let siteId:string;
    this.currentUser$.subscribe(value=>{
      siteId = value.siteId

      if(siteId != null){
        this._blockService.getAllBlockByUser(siteId).subscribe((blocks:IBlock[])=>{
          this.Blocks = blocks;
        },error =>{
          console.log(error);
        })
      }
    });
    
  }

}
