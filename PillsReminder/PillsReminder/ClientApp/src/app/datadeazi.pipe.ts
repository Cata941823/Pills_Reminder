import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'datadeazi'
})
export class DatadeaziPipe implements PipeTransform {

  transform(data: Date): string {
    const daysOfWeek = ['Duminica', 'Luni', 'Marti', 'Miercuri', 'Joi', 'Vineri', 'Sambata'];
    return daysOfWeek[data.getDay()];
  }

}
