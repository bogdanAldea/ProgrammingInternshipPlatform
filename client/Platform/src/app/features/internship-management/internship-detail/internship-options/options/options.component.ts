import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Option } from 'src/app/core/option';
import { Options } from 'src/app/core/options';

@Component({
  selector: 'app-options',
  templateUrl: './options.component.html',
  styleUrls: ['./options.component.scss']
})
export class OptionsComponent implements OnInit {
  public options: Option[] = Options.InternshipOtions;
  public internshipId!: string;

  constructor(private route: ActivatedRoute) {}
  
  ngOnInit(): void {
    this.route.params.subscribe(params => this.internshipId = params['id'])
  }
}
