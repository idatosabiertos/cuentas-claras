import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'amountConverter'
})
export class AmountConverterPipe implements PipeTransform {

  transform(value: any, args?: any): any {
    return `${!args ? '$' : ''}${new Intl.NumberFormat('es', {
      minimumFractionDigits: args ? 0 : 2
    }).format(Number(value))}`;
  }
}
