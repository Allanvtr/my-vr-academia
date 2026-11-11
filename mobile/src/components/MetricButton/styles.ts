import styled from "styled-components/native";
import { responsiveSize } from "../../utils/responsiveSize";

type ContainerProps = {
   selected: boolean;
};

export const Container = styled.TouchableOpacity<ContainerProps>`
    height: ${responsiveSize(88)}px;
    width: ${responsiveSize(150)}px;

    background-color: ${({ theme, selected }) =>
      selected
        ? theme.colors.secondary
        : theme.colors.primary};

    border-radius: 10px;

    flex-direction: row;
    align-items: center;
    justify-content: flex-start;

    padding-horizontal: ${responsiveSize(12)}px;
    gap: ${responsiveSize(8)}px;
`;

export const ButtonText = styled.Text<ContainerProps>`
    flex: 1;
    font-size: ${responsiveSize(24)}px;
    font-family: ${({ theme }) => theme.fonts.medium};
    text-align: left;
    color: ${({ selected }) => 
        selected
            ? 'white'
            : 'black'};
`;