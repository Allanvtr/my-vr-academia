import styled from "styled-components/native";

export const TopContainer = styled.View`
    flex-direction: row;
    align-items: center;
    justify-content: center;
    position: relative;
`;

export const BackButton = styled.TouchableOpacity`
    position: absolute;
    left: 10px;
    margin-top: 45px;
`;

export const Container = styled.View`
  flex: 1;
  background-color: ${({ theme }) => theme.colors.background};
`;

export const MetricTitle = styled.Text`
    text-align: center;
    font-size: 30px;
    font-family: ${({ theme }) => theme.fonts.semiBold};
    margin-top: 40px;
`;

export const SliderContainer = styled.View`
    margin-top: 40px;
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
    padding-horizontal: 10px; 
    bottom: 35px;
    align-self: center;
`;

export const FloatingNumber = styled.Text<{ percentage: number }>`
    font-size: 16px;
    font-family: ${({ theme }) => theme.fonts.semiBold};
    color: #000000;
    text-align: center;
    width: 30px;
    
    left: ${({ percentage }) => percentage}%;
    transform: translateX(-15px); 
`;

export const MetricsButtonsContainer = styled.View`
    width: 100%;
    flex-direction: row;
    flex-wrap: wrap;
    justify-content: center;
    padding: 20px;
    column-gap: 15px;
    row-gap: 20px;
    margin-top: 30px;
`;

export const SubmitButtonContainer = styled.View`
    width: 100%;
    align-items: center;
    margin-top: 50px;
`;