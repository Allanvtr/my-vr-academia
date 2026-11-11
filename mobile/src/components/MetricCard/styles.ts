import styled from "styled-components/native";
import { responsiveSize } from "../../utils/responsiveSize";

export const Container = styled.View`
    background-color: ${({ theme }) => theme.colors.primary};
    width: ${responsiveSize(100)}px;
    height: ${responsiveSize(60)}px;
    border-radius: ${responsiveSize(10)}px;
    flex-direction: row;
    align-items: center;
    padding: 0 ${responsiveSize(14)}px;
    gap: ${responsiveSize(8)}px;
`;

export const MetricValue = styled.Text`
    font-family: ${({ theme }) => theme.fonts.regular};
    font-size: ${responsiveSize(22)}px;
    flex: 1;
    line-height: ${responsiveSize(22)}px;
    text-align: center;
`;