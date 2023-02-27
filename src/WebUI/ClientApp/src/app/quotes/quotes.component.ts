import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CreateQuoteCommand, Quote, QuotesClient, QuoteVm } from '../web-api-client';

@Component({
  selector: 'app-quotes',
  templateUrl: './quotes.component.html',
  styleUrls: ['./quotes.component.scss'],
})
export class QuotesComponent implements OnInit {
  debug = false;
  lists: QuoteVm[];
  newListModalRef: BsModalRef;
  newListEditor: any = {
    text: '',
    characterId: null,
    movieCreateInput: {},
    characterCreateInput: {},
    movieId: null
  };
  serverValidationErrors: any = null;

  constructor(
    private quotesClient: QuotesClient,
    private modalService: BsModalService
  ) {}

  ngOnInit(): void {
    this.reloadQuotes();
  }

  private reloadQuotes():void {
    this.quotesClient.getQuotes().subscribe(
      result => {
        this.lists = result;
      },
      error => console.error(error)
    );
  } 

  private resetModalForm(){
    this.newListEditor = {
      text: '',
      characterId: null,
      movieCreateInput: {},
      characterCreateInput: {},
      movieId: null
    };
    this.serverValidationErrors = null;
  }

  
  newListCancelled(): void {
    this.newListModalRef.hide();
    this.resetModalForm();
  }

  showNewListModal(template: TemplateRef<any>): void {
    this.newListModalRef = this.modalService.show(template);
  }

  addList(): void {

    this.quotesClient.createQuote(this.newListEditor as CreateQuoteCommand).subscribe(
      result => {
        this.reloadQuotes();
        this.newListModalRef.hide();
        this.resetModalForm();
      },
      error => {
        const errors = JSON.parse(error.response);
        this.serverValidationErrors = errors;
      }
    );
  }

  
}
