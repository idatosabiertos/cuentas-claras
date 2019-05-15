import { Action, Selector, State, StateContext } from '@ngxs/store';
import { BuyingIndexStateModel } from './buying-index-state.model';
import { SetBuyingIndexDataAction, SetBuyingIndexSelectedYearAction } from './actions';

@State<BuyingIndexStateModel>({
  name: 'buyingIndex',
  defaults: {
    selectedYear: '2018'
  }
})
export class BuyingIndexState {
  @Selector()
  public static selectedYear(state: BuyingIndexStateModel) {
    return state.selectedYear;
  }

  @Selector()
  public static indexData(state: BuyingIndexStateModel) {
    return state.indexData;
  }


  @Action(SetBuyingIndexSelectedYearAction)
  public setBuyingIndexSelectedYear({patchState}: StateContext<BuyingIndexStateModel>, {payload}: SetBuyingIndexSelectedYearAction) {
    patchState({selectedYear: payload});
  }

  @Action(SetBuyingIndexDataAction)
  public setBuyingIndexData({patchState}: StateContext<BuyingIndexStateModel>, {payload}: SetBuyingIndexDataAction) {
    patchState({indexData: payload});
  }
}
