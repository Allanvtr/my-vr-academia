import styled from 'styled-components/native';
import { responsiveSize } from '../../utils/responsiveSize';

export const Container = styled.View`
    height: ${responsiveSize(60)}px;
    width: 100%;
    background-color: ${({ theme }) => theme.colors.secondary};
    flex-direction: row;
    align-items: center;
    justify-content: space-between;
    padding-left: 30px;
    padding-right: 30px;
    
    position: absolute;
    bottom: 0;
`;

export const IconSize = responsiveSize(32);
export const IconColor = "white"