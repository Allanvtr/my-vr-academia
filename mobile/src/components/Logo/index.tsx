import styled from 'styled-components/native';

export const LogoText = styled.Text`
    font-size: 32px;
    padding-top: 50px;
    font-family: ${({ theme }) => theme.fonts.regular};
    align-self: center;
    text-align: center;
`;

export default function Logo() {
    return (
        <LogoText>My VR Academy</LogoText>
    );
}