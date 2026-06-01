import styled from "styled-components/native";

type ContainerProps = {
   selected: boolean;
};

export const Container = styled.TouchableOpacity<ContainerProps>`
    height: 88px;
    width: 170px;

    background-color: ${({ theme, selected }) =>
      selected
        ? theme.colors.secondary
        : theme.colors.primary};

    border-radius: 10px;

    flex-direction: row;
    align-items: center;
    justify-content: flex-start;

    padding-horizontal: 12px;
    gap: 8px;
`;

export const ButtonText = styled.Text<ContainerProps>`
    flex: 1;
    font-size: 24px;
    font-family: ${({ theme }) => theme.fonts.medium};
    text-align: left;
    color: ${({ selected }) => 
        selected
            ? 'white'
            : 'black'};
`;