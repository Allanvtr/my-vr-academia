import styled from "styled-components/native";
import { responsiveSize } from "../../utils/responsiveSize";

export const Container = styled.TouchableOpacity`
    height: ${responsiveSize(50)}px;
    width: ${responsiveSize(200)}px;
    border-radius: ${responsiveSize(30)}px;
    background-color: ${({ theme }) => theme.colors.secondary};
    align-items: center;
    justify-content: center;
    align-self: center;
    margin-top: ${responsiveSize(10)}px;
`;

export const ButtonText = styled.Text`
    font-family: ${({ theme }) => theme.fonts.medium};
    text-align: left;
    color: white;
    font-size: ${responsiveSize(20)}px;
`
