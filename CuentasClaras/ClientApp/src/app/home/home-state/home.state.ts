import { Action, Selector, State, StateContext } from '@ngxs/store';
import { HomeStateModel } from './home-state';
import {
  SetTopBuyersAction,
  SetTopBuyersSelectedYearAction,
  SetTopItemsAction,
  SetTopItemsSelectedYearAction,
  SetTopSuppliersAction,
  SetTopSuppliersSelectedYearAction
} from './actions';

@State<HomeStateModel>({
  name: 'home',
  defaults: {
    topBuyersSelectedYear: '2017',
    topItemsSelectedYear: '2017',
    topSuppliersSelectedYear: '2017'
  }
})
export class HomeState {
  @Selector()
  public static topBuyers(state: HomeStateModel) {
    return state.topBuyers;
  }

  @Selector()
  public static topBuyersSelectedYear(state: HomeStateModel) {
    return state.topBuyersSelectedYear;
  }

  @Selector()
  public static topSuppliers(state: HomeStateModel) {
    return state.topSuppliers;
  }

  @Selector()
  public static topSuppliersSelectedYear(state: HomeStateModel) {
    return state.topSuppliersSelectedYear;
  }

  @Selector()
  public static topItems(state: HomeStateModel) {
    return state.topItems;
  }

  @Selector()
  public static topItemsSelectedYear(state: HomeStateModel) {
    return state.topItemsSelectedYear;
  }

  @Action(SetTopBuyersAction)
  public setTopBuyers({patchState}: StateContext<HomeStateModel>, {payload}: SetTopBuyersAction) {
    patchState({topBuyers: payload});
  }

  @Action(SetTopBuyersSelectedYearAction)
  public setTopBuyersSelectedYear({patchState}: StateContext<HomeStateModel>, {payload}: SetTopBuyersSelectedYearAction) {
    patchState({topBuyersSelectedYear: payload});
  }

  @Action(SetTopSuppliersAction)
  public setTopSuppliers({patchState}: StateContext<HomeStateModel>, {payload}: SetTopSuppliersAction) {
    patchState({topSuppliers: payload});
  }

  @Action(SetTopSuppliersSelectedYearAction)
  public setTopSuppliersSelectedYear({patchState}: StateContext<HomeStateModel>, {payload}: SetTopSuppliersSelectedYearAction) {
    patchState({topSuppliersSelectedYear: payload});
  }

  @Action(SetTopItemsAction)
  public setTopItemsAction({patchState}: StateContext<HomeStateModel>, {payload}: SetTopItemsAction) {
    patchState({topItems: payload});
  }

  @Action(SetTopItemsSelectedYearAction)
  public setTopItemsSelectedYear({patchState}: StateContext<HomeStateModel>, {payload}: SetTopItemsSelectedYearAction) {
    patchState({topItemsSelectedYear: payload});
  }
}
