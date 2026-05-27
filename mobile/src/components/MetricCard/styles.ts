import styled from "styled-components/native";

export const Container = styled.View`
    background-color: ${({ theme }) => theme.colors.primary};
    width: 110px;
    height: 60px;
    border-radius: 10px;
    flex-direction: row;
    align-items: center;
    padding: 0 14px;
    gap: 8px;
`;

export const MetricValue = styled.Text`
    font-family: ${({ theme }) => theme.fonts.regular};
    font-size: 22px;
    flex: 1;
    line-height: 22px;
    text-align: center;
`;