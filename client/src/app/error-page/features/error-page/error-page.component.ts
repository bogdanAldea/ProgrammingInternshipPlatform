import { Component, OnInit } from '@angular/core';
import { ErrorStateService } from '../../data-access/error-state-service/error-state.service';

@Component({
  selector: 'error-page',
  templateUrl: './error-page.component.html',
  styleUrls: ['./error-page.component.scss']
})
export class ErrorPage implements OnInit {

  public errorCode: number | undefined = 400;

  public constructor(private readonly errorStateService: ErrorStateService) {}
  
  public ngOnInit(): void {
    const error = this.errorStateService.getError();
    this.errorCode = error.status;
    console.log(error)
  }
}
