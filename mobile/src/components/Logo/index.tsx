import styled from 'styled-components/native';
import { responsiveSize } from '../../utils/responsiveSize';

const LogoText = styled.Text`
    font-size: ${responsiveSize(24)}px;
    padding-top: ${responsiveSize(20)}px;
    font-family: ${({ theme }) => theme.fonts.regular};
    align-self: center;
    text-align: center;
`;

export default function Logo() {
    return (
        <LogoText>My VR Academia</LogoText>
    );
}