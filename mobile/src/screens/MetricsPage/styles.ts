import styled from "styled-components/native";
import { responsiveSize } from "../../utils/responsiveSize";

export const TopContainer = styled.View`
    flex-direction: row;
    align-items: center;
    justify-content: center;
    position: relative;
`;

export const BackButton = styled.TouchableOpacity`
    position: absolute;
    left: ${responsiveSize(10)}px;
    margin-top: ${responsiveSize(16)}px;
`;

export const Container = styled.View`
  flex: 1;
  background-color: ${({ theme }) => theme.colors.background};
`;

export const MetricTitle = styled.Text`
    text-align: center;
    font-size: ${responsiveSize(30)}px;
    font-family: ${({ theme }) => theme.fonts.semiBold};
    margin-top: ${responsiveSize(20)}px;
`;

export const SliderContainer = styled.View`
    margin-top: ${responsiveSize(20)}px;
    position: relative;
    justify-content: flex-end;
`;

export const SliderWrapper = styled.View`
    width: 80%;
    align-self: center;
`;

export const FloatingNumberContainer = styled.View`
    position: absolute;
    width: 80%;
    padding-horizontal: ${responsiveSize(10)}px; 
    bottom: ${responsiveSize(35)}px;
    align-self: center;
`;

export const FloatingNumber = styled.Text<{ percentage: number }>`
    font-size: ${responsiveSize(16)}px;
    font-family: ${({ theme }) => theme.fonts.semiBold};
    color: #000000;
    text-align: center;

    width: ${responsiveSize(55)}px;

    left: ${({ percentage }) => percentage}%;
    transform: translateX(-27px);
`;

export const MetricsButtonsContainer = styled.View`
    width: 100%;
    flex-direction: row;
    flex-wrap: wrap;
    justify-content: center;
    padding: ${responsiveSize(20)}px;
    column-gap: ${responsiveSize(15)}px;
    row-gap: ${responsiveSize(20)}px;
    margin-top: ${responsiveSize(20)}px;
`;