import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';


import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { CoreCommonModule } from '@core/common.module';
import { CardSnippetModule } from '@core/components/card-snippet/card-snippet.module';
import { ContentHeaderModule } from 'app/layout/components/content-header/content-header.module';

import { BlockComponent } from './block.component';





const routes = [
  {
    path: 'block',
    component: BlockComponent,
    data: { animation: 'sample' }
  }
];

@NgModule({
  declarations: [
    BlockComponent
  ],
  imports: [
    RouterModule.forChild(routes),
    NgbModule,
    ContentHeaderModule,
    CardSnippetModule,
    CoreCommonModule
  ],
  exports: [BlockComponent]
})
export class BlockModule { }
