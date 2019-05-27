import { Action, Selector, State, StateContext } from '@ngxs/store';
import { HomeStateModel } from './home-state.model';
import {
  SetNetworkSelectedYearAction,
  SetReleaseTypesAction, SetReleaseTypesFilterAction,
  SetReleaseTypesSelectedYearAction,
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
    topBuyersSelectedYear: '2018',
    topItemsSelectedYear: '2018',
    topSuppliersSelectedYear: '2018',
    networkSelectedYear: '2018',
    releaseTypesSelectedYear: '2018',
    releaseTypesFilter: 'amount'
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
  public static networkSelectedYear(state: HomeStateModel) {
    return state.networkSelectedYear;
  }

  @Selector()
  public static topSuppliersSelectedYear(state: HomeStateModel) {
    return state.topSuppliersSelectedYear;
  }

  @Selector()
  public static releaseTypes(state: HomeStateModel) {
    return state.releaseTypes;
  }

  @Selector()
  public static releaseTypesSelectedYear(state: HomeStateModel) {
    return state.releaseTypesSelectedYear;
  }

  @Selector()
  public static releaseTypesFilter(state: HomeStateModel) {
    return state.releaseTypesFilter;
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

  @Action(SetReleaseTypesAction)
  public setReleaseTypesAction({patchState}: StateContext<HomeStateModel>, {payload}: SetReleaseTypesAction) {
    patchState({releaseTypes: payload});
  }

  @Action(SetReleaseTypesSelectedYearAction)
  public setReleaseTypesSelectedYearAction({patchState}: StateContext<HomeStateModel>, {payload}: SetReleaseTypesSelectedYearAction) {
    patchState({releaseTypesSelectedYear: payload});
  }

  @Action(SetReleaseTypesFilterAction)
  public setReleaseTypesFilterAction({patchState}: StateContext<HomeStateModel>, {payload}: SetReleaseTypesFilterAction) {
    patchState({releaseTypesFilter: payload});
  }

  @Action(SetTopItemsAction)
  public setTopItemsAction({patchState}: StateContext<HomeStateModel>, {payload}: SetTopItemsAction) {
    patchState({topItems: payload});
  }

  @Action(SetTopItemsSelectedYearAction)
  public setTopItemsSelectedYear({patchState}: StateContext<HomeStateModel>, {payload}: SetTopItemsSelectedYearAction) {
    patchState({topItemsSelectedYear: payload});
  }

  @Action(SetNetworkSelectedYearAction)
  public setNetworSelectedYear({patchState}: StateContext<HomeStateModel>, {payload}: SetNetworkSelectedYearAction) {
    patchState({networkSelectedYear: payload});
  }
}
