import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgSelectModule } from '@ng-select/ng-select';
import { DragulaModule } from 'ng2-dragula';
import { Ng2FlatpickrModule } from 'ng2-flatpickr';
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { QuillModule } from 'ngx-quill';

import { CoreSidebarModule } from '@core/components';
import { CoreCommonModule } from '@core/common.module';


import { TodoService } from './todo.service';
import { TodoComponent } from './todo.component';
import { TodoListComponent } from './todo-list/todo-list.component';
import { TodoMainSidebarComponent } from './todo-sidebars/todo-main-sidebar/todo-main-sidebar.component';
import { TodoRightSidebarComponent } from './todo-sidebars/todo-right-sidebar/todo-right-sidebar.component';
import { TodoListItemComponent } from './todo-list/todo-list-item/todo-list-item.component';



// routing
const routes: Routes = [
  {
    path: ':filter',
    component: TodoComponent,
    resolve: {
      data: TodoService
    }
  },
  {
    path: 'tag/:tag',
    component: TodoComponent,
    resolve: {
      data: TodoService
    }
  },
  {
    path: '**',
    redirectTo: 'all',
    data: { animation: 'todo' }
  }
];

@NgModule({
  declarations: [
    TodoComponent,
    TodoListComponent,
    TodoMainSidebarComponent,
    TodoRightSidebarComponent,
    TodoListItemComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    CoreCommonModule,
    CoreSidebarModule,
    QuillModule.forRoot(),
    NgSelectModule,
    DragulaModule.forRoot(),
    NgbModule,
    Ng2FlatpickrModule,
    PerfectScrollbarModule
  ],
  providers: [TodoService]
})
export class TodoModule {}
