import { Component, Input } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Coche } from 'src/app/models/coche';

@Component({
  selector: 'app-coches',
  imports: [RouterModule],
  templateUrl: './coches.component.html',
  styleUrls: ['./coches.component.css']
})
export class CochesComponent {
  @Input() coche!: Coche;
}
